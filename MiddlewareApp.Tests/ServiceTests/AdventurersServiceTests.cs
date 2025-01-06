using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using MiddlewareApp.Controllers;
using MiddlewareApp.Model;
using MiddlewareApp.Model.Entity;
using MiddlewareApp.Service;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddlewareApp.Tests.ServiceTests
{
    public class AdventurersServiceTests
    {

        private Mock<IAdventurersRepository> _adventurersRepositoryMock; 

        private AdventurersService _adventurersService;

        [SetUp]
        public void Setup()
        {
            _adventurersRepositoryMock = new Mock<IAdventurersRepository>();
            _adventurersService = new AdventurersService(_adventurersRepositoryMock.Object);

        }

        [Test]
        public void GetAllAdventurers_ReturnsAllAdventurers()
        {
            List<Adventurer> adventurersList = new List<Adventurer>()
            {
                new Adventurer("JonJon", FightingClass.WARRIOR)
                {
                    Level = 2,
                    XP = 2
                }
            };

            _adventurersRepositoryMock.Setup(service => service.FetchAdventurers()).Returns(adventurersList);

            var result = _adventurersService.GetAllAdventurers();

            result.Should().BeEquivalentTo(adventurersList);
        

        }

        [Test]
        public void GetAllAdventurers_ReturnsEmptyList()
        {
            List<Adventurer> adventurersList = new List<Adventurer>()
            {
            };

            _adventurersRepositoryMock.Setup(service => service.FetchAdventurers()).Returns(adventurersList);

            var result = _adventurersService.GetAllAdventurers();

            result.Should().BeEquivalentTo(adventurersList);

        }


        [Test]
        public void AddAdventurer_CallsCorrectMethod()
        {
            Adventurer newAdventurer = new Adventurer("Jonno", 0);

            _adventurersService.AddAdventurer(newAdventurer);

            _adventurersRepositoryMock.Verify(repo => repo.AddAdventurer(newAdventurer), Times.Once); 

    
        }



    }
}

﻿using MiddlewareApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using FluentAssertions;
using MiddlewareApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using MiddlewareApp.Model.Entity;
using Microsoft.AspNetCore.Http.HttpResults;


namespace MiddlewareApp.Tests.ControllerTests
{
    public class AdventurersControllerTests
    {
        private Mock<IAdventurersService> _adventurersServiceMock;

        private AdventurersController _adventurersController; 

        [SetUp]
        public void Setup()
        {
            _adventurersServiceMock = new Mock<IAdventurersService>(); 
            _adventurersController = new AdventurersController(_adventurersServiceMock.Object);

        }

        [TearDown]
        public void CleanUp()
        {
            _adventurersController.Dispose();
        }

        [Test]
        public void GetRequest_ReturnsAllAdventurers()
        {
            List<Adventurer> adventurersList = new List<Adventurer>()
            {
                new Adventurer("JonJon", FightingClass.WARRIOR)
                {
                    Level = 2,
                    XP = 2
                }
            }; 

            _adventurersServiceMock.Setup(service => service.GetAllAdventurers()).Returns(adventurersList);

            var result = _adventurersController.GetAdventurers();

            if (result is OkObjectResult okObjectResult)
            {
                okObjectResult.StatusCode.Should().Be(200);
                okObjectResult.Value.Should().BeEquivalentTo(adventurersList);
            } else
            {
                Assert.Fail(); 
            }

        }


        [Test]
        public void GetRequest_ReturnsEmptyList()
        {
            List<Adventurer> adventurersList = new List<Adventurer>()
            {
            };

            _adventurersServiceMock.Setup(service => service.GetAllAdventurers()).Returns(adventurersList);

            var result = _adventurersController.GetAdventurers();

            if (result is NotFoundObjectResult notFoundObjectResult)
            {
                notFoundObjectResult.StatusCode.Should().Be(404);
                notFoundObjectResult.Value.Should().Be("No adventurers found");
            }
            else
            {
                Assert.Fail();
            }

        }

        [Test]
        public void PostRequest_ValidInput_Returns200()
        {
            Adventurer newAdventurer = new Adventurer("Jonno", 0);

            var result = _adventurersController.AddAdventurer(newAdventurer);

            if (result is CreatedResult createdResult)
            {
                createdResult.StatusCode.Should().Be(201);
                createdResult.Value.Should().Be($"{newAdventurer.Name} has been added");
            }
            else
            {
                Assert.Fail();
            }
        }

        //[Test]
        //public void PostRequest_InvalidInput_Returns200()
        //{
        //    Adventurer newAdventurer = new Adventurer("Jonno", 0);

        //    var result = _adventurersController.AddAdventurer(newAdventurer);

        //    _adventurersController.ModelState.AddModelError("FightingClass", "This is a not a valid Fighting Class");

        //    if (result is BadRequestObjectResult badRequestObjectResult)
        //    {
        //        badRequestObjectResult.StatusCode.Should().Be(400);
        //    }
        //    else
        //    {
        //        Assert.Fail();
        //    }
        //}




    }
}

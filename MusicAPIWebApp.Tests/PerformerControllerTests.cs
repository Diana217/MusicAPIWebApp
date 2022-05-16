using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicAPIWebApp.Models;
using Xunit;

namespace MusicAPIWebApp.Tests
{
    public class PerformerControllerTests
    {
        [Fact]
        public async void Test1()
        {
            // Arrange
            var optionsBuilder = new DbContextOptionsBuilder<MusicAPIContext>();
            optionsBuilder.UseSqlServer("Server=DESKTOP-J8EAKAU\\SQLEXPRESS; Database=MusicAPI; Trusted_Connection=True; MultipleActiveResultSets=true");

            var controller = new PerformersController(new MusicAPIContext(optionsBuilder.Options));

            // Act
            var result = await controller.GetPerformers();

            // Assert
            Assert.Contains(result.Value, g => g.Name.Equals("Антоніо Вівальді"));
        }
    }
}

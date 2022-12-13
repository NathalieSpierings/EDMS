using AutoFixture;
using NUnit.Framework;
using Promeetec.EDMS.Domain.Models.Menu.MenuItem.Commands;
using Promeetec.EDMS.Domain.Tests.Helpers;

namespace Promeetec.EDMS.Domain.Tests.Menu.MenuItem
{
    [TestFixture]
    public class MenuItemTests : TestFixtureBase
    {
        private Models.Menu.Menu.Menu _sut;
        private AddMenuItem _cmd;
        private Models.Menu.MenuItem.MenuItem _menuItem;
        private Guid _createId;


        [SetUp]
        public void Setup()
        {
            _createId = Guid.NewGuid();

            _sut = Fixture.Build<Models.Menu.Menu.Menu>()
                .Without(x => x.MenuItems)
                .With(x => x.MenuItems, Fixture.Build<Models.Menu.MenuItem.MenuItem>()
                    .Without(x => x.Roles)
                    .CreateMany().ToList())
                .Create();
            

            _cmd = Fixture.Build<AddMenuItem>()
                .Without(x => x.Roles)
                .With(x => x.Id, _createId)
                .Create();

            _sut.AddMenuItem(_cmd);

            _menuItem = _sut.MenuItems.FirstOrDefault(c => c.Id == _cmd.Id);
        }


        [Test]
        public void Should_add_menu_item()
        {
            Assert.IsNotNull(_menuItem);
        }

        [Test]
        public void Should_set_sort_order()
        {
            Assert.AreEqual(1, _menuItem.SortOrder);
        }

        [Test]
        public void Should_remove_menu_item()
        {
            var itemToRemove = Fixture.Create<RemoveMenuItem>();
            _sut.RemoveMenuItem(itemToRemove);

            
        }
    }
}
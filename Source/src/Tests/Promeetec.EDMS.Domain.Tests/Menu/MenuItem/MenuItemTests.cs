using AutoFixture;
using NUnit.Framework;
using Promeetec.EDMS.Portaal.Domain.Models.Menu.MenuItem.Commands;
using Promeetec.EDMS.Portaal.Tests.Helpers;

namespace Promeetec.EDMS.Portaal.Domain.Tests.Menu.MenuItem
{
    [TestFixture]
    public class MenuItemTests : TestFixtureBase
    {
        private Models.Menu.Menu.Menu _sut;
        private AddMenuItem _cmd;
        private Models.Menu.MenuItem.MenuItem? _menuItem;
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
            Assert.AreEqual(_menuItem.MenuId, _menuItem.MenuId);
            Assert.AreEqual(_menuItem.ParentId, _menuItem.ParentId);
            Assert.AreEqual(_menuItem.ClientName, _menuItem.ClientName);
            Assert.AreEqual(_menuItem.Key, _menuItem.Key);
            Assert.AreEqual(_menuItem.Title, _menuItem.Title);
            Assert.AreEqual(_menuItem.Tooltip, _menuItem.Tooltip);
            Assert.AreEqual(_menuItem.Icon, _menuItem.Icon);
            Assert.AreEqual(_menuItem.ActionName, _menuItem.ActionName);
            Assert.AreEqual(_menuItem.ControllerName, _menuItem.ControllerName);
            Assert.AreEqual(_menuItem.RouteVariables, _menuItem.RouteVariables);
            Assert.AreEqual(_menuItem.Url, _menuItem.Url);
            Assert.AreEqual(_menuItem.Status, _menuItem.Status);
            Assert.AreEqual(_menuItem.MenuItemType, _menuItem.MenuItemType);
            Assert.AreEqual(_menuItem.SortOrder, _menuItem.SortOrder);
        }

        [Test]
        public void Should_set_sort_order()
        {
            Assert.AreEqual(1, _menuItem.SortOrder);
        }


        [Test]
        public void Should_update_menu_item()
        {
            var cmd = Fixture.Create<UpdateMenuItem>();
            _menuItem.Update(cmd);

            Assert.AreEqual(cmd.ClientName, _menuItem.ClientName);
            Assert.AreEqual(cmd.Key, _menuItem.Key);
            Assert.AreEqual(cmd.Title, _menuItem.Title);
            Assert.AreEqual(cmd.Tooltip, _menuItem.Tooltip);
            Assert.AreEqual(cmd.Icon, _menuItem.Icon);
            Assert.AreEqual(cmd.ActionName, _menuItem.ActionName);
            Assert.AreEqual(cmd.ControllerName, _menuItem.ControllerName);
            Assert.AreEqual(cmd.RouteVariables, _menuItem.RouteVariables);
            Assert.AreEqual(cmd.Url, _menuItem.Url);
            Assert.AreEqual(cmd.MenuItemType, _menuItem.MenuItemType);
            Assert.AreEqual(cmd.Status, _menuItem.Status);
        }

        //[Test]
        //public void Should_reorder()
        //{
        //    _menuItem.Reorder(cmd);

        //    Assert.AreEqual(1, _menuItem.ParentId);
        //    Assert.AreEqual(1, _menuItem.SortOrder);
        //}

        //[Test]
        //public void Should_remove_menu_item()
        //{
        //    var itemToRemove = Fixture.Create<RemoveMenuItem>();
        //    _sut.RemoveMenuItem(itemToRemove);
        //}
    }
}
using System;

namespace Promeetec.EDMS.Reporting.Private.ContextMenu;

public enum GridContextMenuItemType
{
    Link, // De href van een link wordt gezet
    Load, // Content kan via ajax geladen worden
    LoadInSlidepanel, // Content wordt geladen via ajax in een slidepanel
    LoadInTabbedSlidepanel // Content wordt geladen via ajax in een tabbed slidepanel

}

/// <summary>
/// Soms hebben we het ID beschikbaar in de ViewModel. Geef dan de RouteValues op en zet Active op true.
/// De RouteValues zijn nodig als je de details, activiteit content in de tabbed slidepanel wilt laden. We zetten dan de querystring op de tabs.
/// Zie hiervoor bijv. organisatie => overzicht.js
/// Als je details wilt laden in de slidepanel kan dat door de functie promeetec.edms.loadSlidepanelcontent() aan te roepen.
/// Wil je de tab versie laden roep dan de promeetec.edms.loadSlidepanelTabcontent() functie aan.
/// </summary>
/// <seealso cref="IEquatable{GridContextMenu}" />
public class GridContextMenu : IEquatable<GridContextMenu>
{
    public GridContextMenu()
    {
    }

    public string ClientName { get; set; }
    public string Icon { get; set; }
    public string Title { get; set; }
    public int? Total { get; set; }
    public GridContextMenuItemType Type { get; set; }
    public string Url { get; set; }
    public string Key { get; set; }
    public object RouteValues { get; set; }
    public bool Active { get; set; } = false;
    public string[] Roles { get; set; }


    public bool Equals(GridContextMenu other)
    {
        if (other == null)
            return false;

        return string.Equals(Title, other.Title) &&
               string.Equals(Url, other.Url);
    }
}
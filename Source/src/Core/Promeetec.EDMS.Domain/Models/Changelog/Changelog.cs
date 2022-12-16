using System.ComponentModel.DataAnnotations;
using Promeetec.EDMS.Domain.Models.Changelog.Commands;

namespace Promeetec.EDMS.Domain.Models.Changelog;

public class Changelog : AggregateRoot
{
    /// <summary>
    /// The date of the release.
    /// </summary>
    [Required]
    public DateTime Date { get; set; }

    /// <summary>
    /// The title of the release notes.
    /// </summary>
    [Required, MaxLength(200)]
    public string Title { get; set; }

    /// <summary>
    /// The short description of the release notes.
    /// </summary>
    [Required, MaxLength(450)]
    public string Description { get; set; }


    /// <summary>
    /// The content of the release notes.
    /// </summary>
    [Required, MaxLength]
    public string Content { get; set; }


    /// <summary>
    /// The type of the release.
    /// </summary>
    public ChangeLogType Type { get; set; }


    /// <summary>
    /// The tags describing the domain of the release notes.
    /// </summary>
    [MaxLength(128)]
    public string? Tag { get; set; }



    /// <summary>
    /// Creates an empty changelog post.
    /// </summary>
    public Changelog()
    {
    }


    /// <summary>
    /// Creates a changelog post.
    /// </summary>
    /// <param name="cmd">The create changelog post command.</param>
    public Changelog(CreateChangelogPost cmd)
    {
        Id = cmd.Id;

        Date = cmd.Date;
        Title = cmd.Title;
        Description = cmd.Description;
        Content = cmd.Content;
        Type = cmd.Type;
        Tag = cmd.Tag;
    }

    /// <summary>
    /// Update the details of the changelog post.
    /// </summary>
    /// <param name="cmd">The update changelog post command.</param>
    public void Update(UpdateChangelogPost cmd)
    {
        Date = cmd.Date;
        Title = cmd.Title;
        Description = cmd.Description;
        Content = cmd.Content;
        Type = cmd.Type;
        Tag = cmd.Tag;
    }

    /// <summary>
    /// Deletes a changelog post.
    /// </summary>
    /// <param name="cmd">The delete changelog post command.</param>
    public void Delete(DeleteChangelogPost cmd)
    {
    }
}

using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Admin.Logboek.Models;

public class LogboekViewModel : ModelBase
{
    public DirectoryTree Directory { get; set; }
}


public class DirectoryTree
{
    public bool IsRoot;
    public string Name;
    public DirectoryInfo FullName;
    public DirectoryTree Parent;
    public List<DirectoryTree> Folders = new();
    public FileInfo[] FileInfos { get; set; }


    public DirectoryTree(DirectoryInfo root, DirectoryTree parent)
    {
        if (parent == null)
            IsRoot = true;

        FullName = root;
        Name = root.Name;
        Parent = parent;

        foreach (string filePath in Directory.GetDirectories(root.FullName))
        {
            Folders.Add(new DirectoryTree(new DirectoryInfo(filePath), this));
        }

        try
        {
            FileInfos = root.GetFiles("*.*");
        }
        catch (UnauthorizedAccessException e) // This is thrown if even one of the files requires permissions greater than the application provides.
        {
            // This code just writes out the message and continues to recurse.
            // You may decide to do something different here. For example, you
            // can try to elevate your privileges and access the file again.
            Console.WriteLine(e.Message);
        }
        catch (DirectoryNotFoundException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
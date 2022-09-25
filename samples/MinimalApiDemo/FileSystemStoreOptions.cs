// Copyright (c) Nate McMaster.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using static System.Environment;

namespace MinimalApiDemo;
public class FileSystemStoreOptions
{
    public string? Path { get; set; }

    public string? Password { get; set; }

    public FileSystemStoreOptions ValidateAndTransform()
    {
        if (string.IsNullOrWhiteSpace(this.Path))
        {
            throw new Exception("FileSystem Store Path is required!");
        }
        if (string.IsNullOrWhiteSpace(this.Password))
        {
            throw new Exception("FileSystem Store Passwod is required!");
        }
        if (!System.IO.Path.IsPathRooted(this.Path))
        {
            this.Path = System.IO.Path.Combine(
                Environment.GetFolderPath(SpecialFolder.UserProfile),
                this.Path);
        }
        if (!Directory.Exists(this.Path))
        {
            Directory.CreateDirectory(this.Path);
        }
        return this;
    }
}

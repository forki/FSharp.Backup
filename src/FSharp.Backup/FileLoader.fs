module FSharp.Backup.FileLoader

open DomainTypes

let load loader filePath =
    (FileName "a", None) |> File |> Some
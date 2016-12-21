module FSharp.Backup.FileLoader

open System.IO
open DomainTypes

let load loader filePath =
    try
        loader filePath
    with
    | :? FileNotFoundException -> None
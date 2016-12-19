module FSharp.Backup.Tests.FileTypeTests

open FSharp.Backup.DomainTypes
open Xunit
open FsCheck
open FsCheck.Xunit
open Swensen.Unquote

[<Property>]
let ``File can be constructed without extension`` (NonNull s) =
    let fileName = FileName s
    let file = File (fileName, None)

    sprintf "%A" file =! s

[<Property>]
let ``File can be constructed with extension`` (NonNull fileNameString) (NonNull fileExtensionString) =
    let fileName = FileName fileNameString
    let fileExtension = FileExtension fileExtensionString

    let file = File (fileName, Some fileExtension)

    sprintf "%A" file =! sprintf "%s.%s" fileNameString fileExtensionString

[<Property>]
let ``Directory returns correct string representation`` (NonNull dirNameString) f =
    let dirName = DirectoryName dirNameString

    let dir = Directory (dirName, f)

    sprintf "%A" dir =! sprintf "Directory: %s" dirNameString
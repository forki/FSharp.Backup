module FSharp.Backup.Tests.FileTypeTests

open FSharp.Backup.DomainTypes
open Xunit
open FsCheck
open FsCheck.Xunit
open Swensen.Unquote

[<Property>]
let ``File can be constructed`` (NonNull s) =
    let fileName = FileName s
    let file = File (fileName, None)
    sprintf "%A" file =! s
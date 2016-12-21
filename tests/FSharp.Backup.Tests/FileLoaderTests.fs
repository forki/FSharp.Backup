module FSharp.Backup.Tests.FileLoaderTests

open FSharp.Backup.DomainTypes
open FSharp.Backup.FileLoader
open Swensen.Unquote
open Xunit

let (|DummyFilePath|_|) = function
    | "C:/users/foo/Desktop/a" ->
        (FileName "a", None) |> File |> Some
    | _ -> None

[<Fact>]
let ``FileLoader can load a file without extension`` () =
    let filePath = "C:/users/foo/Desktop/a"

    let result = load (|DummyFilePath|_|) filePath

    test <@ Option.isSome result @>


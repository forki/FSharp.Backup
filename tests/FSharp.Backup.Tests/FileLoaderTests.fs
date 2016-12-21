module FSharp.Backup.Tests.FileLoaderTests

open FsCheck.Xunit
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

[<Fact>]
let ``FileLoader returns none when file does not exist`` () =
    let filePath = "dummy"

    let result = load (|DummyFilePath|_|) filePath

    test <@ Option.isNone result @>

[<Property>]
let ``FileLoader returns none while fileLoader throws FileNotFoundException`` (filePath: string) =
    let fileLoader _ = raise <| System.IO.FileNotFoundException ()

    let result = load fileLoader filePath

    test <@ Option.isNone result @>
module FSharp.Backup.Tests.OptionHelperTests

open Option
open FsCheck.Xunit
open Swensen.Unquote

[<Property>]
let ``Either returns same underlying value when given id`` (x: int) none =
    let xOpt = Some x
    
    let result = either id none xOpt

    x =! result

[<Property>]
let ``Either returns none value when input option is None`` (none: int) =
    let result = either id none None

    result =! none
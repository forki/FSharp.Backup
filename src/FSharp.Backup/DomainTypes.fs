module FSharp.Backup.DomainTypes

open System

type FileName = FileName of string

type DirectoryName = DirectoryName of string

[<StructuredFormatDisplay("{AsString}")>]
type FileExtension = 
    | FileExtension of string
    override this.ToString () =
        let (FileExtension s) = this
        sprintf ".%s" s
    member private this.AsString = this.ToString ()

[<StructuredFormatDisplay("{AsString}")>]
type FileType =
    | File of FileName * FileExtension option
    | Directory of DirectoryName * FileType
    override this.ToString() =
        match this with
        | File (FileName fileName, extOpt) ->
            let extension = Option.either (sprintf "%A") String.Empty extOpt
            sprintf "%s%s" fileName extension
        | Directory (DirectoryName dirName, _) ->
            sprintf "Directory: %s" dirName
    member private this.AsString = this.ToString ()
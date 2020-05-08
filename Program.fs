// Learn more about F# at http://fsharp.org

open System
// #r "C:/Users/ellam/.nuget/packages/fsharp.data/3.3.3/lib/net45/FSharp.Data.dll"
open FSharp.Data

module CSVRead = 

//  zls = zero length string or ""     
    let zls = "" 
//  3 string collection type examples 
    let ZLSSeq : string seq = seq [zls] 
    let ZLSList : string list = [zls] 
    let ZLSArray : string [] = [|zls|]

//  discards the option on a string array 
    let fromSome (y : string [] option) =
        match y with 
        | Some(y) -> y 
        | None -> ZLSArray 

//  __SOURCE_DIRECTORY__;;
//  val it : string = "c:\Users\ellam\Documents\MatthewDWhite\D\F#\Code\CSV"
    let [<Literal>] CsvFile = __SOURCE_DIRECTORY__ + "/" + "common.in.TableIn.csv" 
//  let [<Literal>] CsvFile = __SOURCE_DIRECTORY__ + "/" + fileNameIn          
//  cannot pass in filename as an argument and convert to a literal 
//  a literal must be hardcoded at compile time. 
//  Could a generated pre-compile step be used to simulate arguments? 
//  test for missing file 

//  type TableIn = CsvProvider<"common.in.TableIn.csv">
//  this works well with a Literal val, but it will not accept an ordinary string val 
    type TableIn = CsvProvider<CsvFile> 
//  test for csv error

//  primary function 
    let CsvHeader (fileNameIn : string) =
//     let CsvFileLoc = __SOURCE_DIRECTORY__ + "/" + "common.in.TableIn.csv" 
       let csvFileLoc = __SOURCE_DIRECTORY__ + "/" + fileNameIn 

//     let tableIn = TableIn.Load("common.in.TableIn.csv")
//     this path can be changed, so that identically typed files can be loaded from different places 
       let tableIn = TableIn.Load(csvFileLoc)
//     test for load error 

//     pipelines the column headers to a string  
       fromSome tableIn.Headers |> Array.toList |> String.concat "\t" 

//    dotnet run "common.in.TableIn.csv" -> OK 
//    dotnet run "common.in.TableIn.csv" "x" -> generates missing file exception 
[<EntryPoint>]
let main argv =
    for name in argv do 
        let hdrs = CSVRead.CsvHeader name 
        printfn  "headers: %s" hdrs 
    0 // return an integer exit code

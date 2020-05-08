
open System ;;

#r @"C:\Users\ellam\.nuget\packages\fsharp.data\3.3.3\lib\netstandard2.0\FSharp.Data.dll" ;; 

open FSharp.Data ;;

//   zls = zero length string or ""     
let zls = ""  
//  3 string collection type examples 
let ZLSArray : string [] = [|zls|] 

//  discards the option on a string array 
let fromSome (y : string [] option) =
        match y with 
        | Some(y) -> y 
        | None -> ZLSArray 

type TableIn = FSharp.Data.CsvProvider<"common.in.TableIn.csv">  

//  note that the type is obj, not CsvProvider<...> 
let tableIn = TableIn.Load("common.in.TableIn.csv") ;;
//  the .Load method is not returning the correct type in this script. 
//  this does work in the *.fs program. 

//  pipelines the column headers to a string 
//  let hdrString = fromSome tableIn.Headers |> Array.toList |> String.concat "\t" 
       fromSome tableIn.Headers |> Array.toList |> String.concat "\t" 
// __SOURCE_DIRECTORY__

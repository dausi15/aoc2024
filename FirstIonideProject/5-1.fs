open System
open System.IO

let inputLines = File.ReadAllLines(@"C:\src\aoc2024\aoc2024\FirstIonideProject\input\5.1.1.txt") |> List.ofArray
let pages = File.ReadAllLines(@"C:\src\aoc2024\aoc2024\FirstIonideProject\input\5.1.2.txt") |> List.ofArray |> List.map (fun line -> line.Split(",") |> List.ofArray)

let rules = [ for f in inputLines -> f,f ] |> Map.ofSeq

let getRule x y =
    y + "|" + x

let conflict x y = 
    rules |> Map.containsKey (getRule x y)

let hasConflicts x rest =
    let result = List.tryFind (fun item -> (conflict x item)) rest
    match result with
    | Some _ -> true
    | None -> false

let rec checkIsValid list =
    match list with
    | [] -> true
    | head::tail -> 
        if hasConflicts head tail then
            false
        else
            checkIsValid tail


let checkPage page = 
    let valid = checkIsValid page
    match valid with
    | true -> page[(page.Length/2)]
    | _ -> ""

let solve = 
    pages |> List.iter (fun p ->
    match p with
    | [] -> ()
    | _ -> printfn "%s" (checkPage p))
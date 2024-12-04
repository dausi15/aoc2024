open System
open System.IO

let inputLines = File.ReadAllLines(@"C:\src\aoc2024\FirstIonideProject\input\3.22.txt") |> List.ofArray

// Function to split each line into two integers and return two separate lists
let splitColumns (lines: string list) =
    let firstColumn = 
        lines
        |> List.map (fun line -> line.Split("   ").[0] |> int) // Extract the first column
    let secondColumn = 
        lines
        |> List.map (fun line -> line.Split("   ").[1] |> int) // Extract the second column
    (firstColumn, secondColumn) // Return a tuple of the two lists

let firstColumn, secondColumn = splitColumns inputLines

printfn "First Column: %A" firstColumn
printfn "Second Column: %A" secondColumn

let listZip = List.zip firstColumn secondColumn

printfn "First zip: %A" listZip;;

let getDistance (x1,y1) =
    (x1*y1)

let printSum listZip =
    listZip |> List.map getDistance |> List.sum

// mul\(([1-9]|[1-9][0-9]{1,2}),([1-9]|[1-9][0-9]{1,2})\)
printSum listZip
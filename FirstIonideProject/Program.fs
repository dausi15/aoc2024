open System
open System.IO

// let lines = File.ReadAllLines(@"C:\src\aoc2024\FirstIonideProject\1.txt")

// let inputLines = [
//     "3 4"
//     "4 3"
//     "2 5"
//     "1 3"
//     "3 9"
//     "3 3"
// ]

let inputLines = File.ReadAllLines(@"C:\src\aoc2024\FirstIonideProject\1.txt") |> List.ofArray

// Function to split each line into two integers and return two separate lists
let splitColumns (lines: string list) =
    let firstColumn = 
        lines
        |> List.map (fun line -> line.Split("   ").[0] |> int) // Extract the first column
    let secondColumn = 
        lines
        |> List.map (fun line -> line.Split("   ").[1] |> int) // Extract the second column
    (firstColumn, secondColumn) // Return a tuple of the two lists

// Split the columns and print the results
let firstColumn, secondColumn = splitColumns inputLines

// let solve (list1: List<int>, list2: List<int>) =
//     let list1 = List.sort list1
//     let list2 = list.sort list2

printfn "First Column: %A" firstColumn
printfn "Second Column: %A" secondColumn


let list1 = List.sort firstColumn
let list2 = List.sort secondColumn

let listZip = List.zip list1 list2

printfn "First zip: %A" listZip;;

// let getDistance ((x1,y1): int*int) =
//     (x1-y1) 
//     |> abs 

let getDistance (x1,y1) =
    (x1-y1) 
    |> abs 

// List.iter (fun (x, y) -> printfn "%A" (getDistance (x, y))) listZip

// let a = List.iter (fun (x, y) -> (getDistance (x, y))) listZip
// let sum2 = List.sumBy (fun elem -> elem+elem) a
// printfn "%d" a

let printSum listZip =
    listZip |> List.map getDistance |> List.sum

printSum listZip
open System
open System.IO

let inputLines = File.ReadAllLines(@"C:\src\aoc2024\FirstIonideProject\input\4.txt") |> List.ofArray

// Function to convert a list of strings into a 2D Array (Array2D)
let convertTo2DArray (lines: string list) =
    // Get the number of rows and columns from the input
    let numRows = lines.Length
    let numCols = lines.Head.Length

    // Create a 2D array with the correct dimensions
    let arr2D = Array2D.zeroCreate numRows numCols

    // Fill the 2D array by iterating over the list of strings and placing characters into the array
    for i in 0 .. numRows - 1 do
        for j in 0 .. numCols - 1 do
            arr2D.[i, j] <- lines.[i].[j]

    arr2D
// Thanks ChatGPT

// PART 2

// Convert the list of strings to a 2D array
let twoDArray = convertTo2DArray inputLines

let mutable count = 0

let NorthEast x y i = twoDArray[x+i, y+i]
let NorthWest x y i = twoDArray[x-i, y+i]
let SouthEast x y i = twoDArray[x+i, y-i]
let SouthWest x y i = twoDArray[x-i, y-i]


let findwords x y = 
    try
        try
            let a = NorthEast x y 1
            let b = NorthWest x y 1
            let c = SouthEast x y 1
            let d = SouthWest x y 1
            let pattern = a.ToString() + b.ToString() + c.ToString() + d.ToString()
            match pattern with
            | "MMSS" -> count <- count + 1
            | "MSMS" -> count <- count + 1
            | "SSMM" -> count <- count + 1
            | "SMSM" -> count <- count + 1
            | _ -> ()
        with
            | :? System.IndexOutOfRangeException -> ()
    finally
        ()


let solve = Array2D.iteri (fun i j v -> 
    match v with
    | 'A' -> findwords i j
    | _ -> ()) twoDArray

printfn "%A" count
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

// PART 1
let word = ['M', 'A', 'S']

// Convert the list of strings to a 2D array
let twoDArray = convertTo2DArray inputLines

let mutable count = 0

let North x y i = twoDArray[x, y+i]
let South x y i = twoDArray[x, y-i]
let East x y i = twoDArray[x+i, y]
let West x y i = twoDArray[x-i, y]
let NorthEast x y i = twoDArray[x+i, y+i]
let NorthWest x y i = twoDArray[x-i, y+i]
let SouthEast x y i = twoDArray[x+i, y-i]
let SouthWest x y i = twoDArray[x-i, y-i]

let findAllWordsInDirection func x y = 
    try
        try
            let mutable word = ""
            for i in 1 .. 3 do
                let what = func x y i
                word <- word + string what
            if word = "MAS" then
                count <- count + 1
        with
            | :? System.IndexOutOfRangeException -> ()//printfn "Exception!"
    finally
        // printfn "Did not find anything"
        ()


let findwords x y =
    findAllWordsInDirection North x y
    findAllWordsInDirection South x y
    findAllWordsInDirection East x y
    findAllWordsInDirection West x y
    findAllWordsInDirection NorthEast x y
    findAllWordsInDirection NorthWest x y
    findAllWordsInDirection SouthEast x y
    findAllWordsInDirection SouthWest x y

let solve = Array2D.iteri (fun i j v -> 
    match v with
    | 'X' -> findwords i j
    | _ -> ()) twoDArray

printfn "%A" count
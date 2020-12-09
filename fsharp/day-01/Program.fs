let readLines filePath = System.IO.File.ReadLines(filePath)
let generateComplement intValue = 2020 - intValue

let numbersFromFile = 
    let lines = readLines "./input.txt"
    let ints = lines |> Seq.map(int)
    ints

let twoNumbers = 
    let ints = numbersFromFile
    let complements = numbersFromFile |> Seq.map(generateComplement)
    let matches = Set.intersect (Set.ofSeq ints) (Set.ofSeq complements)
    matches

let setMultiplication numbers = numbers |> Set.fold (*) 1

[<EntryPoint>]
let main argv =
    let result = twoNumbers |> setMultiplication

    printf "%i" result
    0
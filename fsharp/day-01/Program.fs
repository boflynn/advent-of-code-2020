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

let threeNumbers =
    let ints = numbersFromFile
    let intList = ints |> Seq.toList
    let trips = List.allPairs intList (List.allPairs intList intList)
    let corrects = trips |> List.filter (fun (a, (b, c)) -> (a + b + c) = 2020)
                         |> List.head
    corrects

[<EntryPoint>]
let main argv =
    let partOneResult = twoNumbers |> setMultiplication
    printf "%A\r\n" partOneResult

    let partThreeResult = threeNumbers |> fun (a, (b, c)) -> a * b * c

    printf "%A\r\n" partThreeResult
    0
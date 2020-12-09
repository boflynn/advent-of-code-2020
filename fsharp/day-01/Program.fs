let readLines filePath = System.IO.File.ReadLines(filePath)
let generateComplement intValue = 2020 - intValue

[<EntryPoint>]
let main argv =
    let lines = readLines "./input.txt"
    let ints = lines |> Seq.map(int)
    let complements = ints |> Seq.map(generateComplement)
    let matches = Set.intersect (Set.ofSeq ints) (Set.ofSeq complements)
    let multiplication = matches |> Set.fold (*) 1

    printf "%i" multiplication
    0
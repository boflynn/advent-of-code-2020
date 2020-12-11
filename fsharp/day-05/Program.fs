let readLines = System.IO.File.ReadAllLines("./input.txt")
let seatNumbers = readLines |> Seq.map(fun(a) -> a |> Seq.map(fun(a) -> match a with
                                                                                 | 'B' -> "1"
                                                                                 | 'F' -> "0"
                                                                                 | 'R' -> "1"
                                                                                 | 'L' -> "0"
                                                                                 | _ -> "z"
                                                                                 )
                                                            |> String.concat "" )
let seatIds = seatNumbers |> Seq.map(fun(a) -> System.Convert.ToInt32(a, 2))

[<EntryPoint>]
let main argv =
    let sorted = seatIds |> Seq.toList |> List.sort
    let first = sorted |> List.head
    let last = sorted |> List.rev |> List.head
    let actualSum = sorted |> Seq.sum
    let expectedSum = (last - first + 1) * (first + last) / 2

    printfn "%A" (expectedSum - actualSum)
    0

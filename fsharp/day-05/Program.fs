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
    seatIds |> Seq.max
            |> printfn "%A"
    0
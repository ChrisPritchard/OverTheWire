open System
open System.Text

let b64decode s =
    let bytes = Convert.FromBase64String s
    Encoding.ASCII.GetString bytes

let rot n (s: string) =
    let minA = int 'A'
    let maxZ = int 'Z'
    let buffer = s.ToCharArray()
    for i in [0..buffer.Length - 1] do
        buffer.[i] <-
            let c = int buffer.[i]
            if c < minA || c > maxZ then buffer.[i]
            else
                let rotated = c + n
                let bound = 
                    if rotated > maxZ 
                    then rotated - 26 
                    elif rotated < minA 
                    then (minA - rotated) + maxZ + 1
                    else rotated
                char bound
    String(buffer)

// Krypton 1:
printfn "Krypton 1: %s" <| b64decode "S1JZUFRPTklTR1JFQVQ="

// Krypton 2:
printfn "Krypton 2: %s" <| rot -13 "LEVEL TWO PASSWORD ROTTEN"//"YRIRY GJB CNFFJBEQ EBGGRA"
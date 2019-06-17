open System
open System.Text
open System.IO

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
                    then maxZ - (minA - (rotated + 1))
                    else rotated
                char bound
    String(buffer)

let freqDecode =
    let freqCode = 
        [|  'e';'t';'a';'o';'i';'n';'s';
            'h';'r';'d';'l';'c';'u';'m';
            'w';'f';'g';'y';'p';'b';'v';
            'k';'j';'x';'q';'z' |]
    Seq.countBy id
    >> Seq.sortByDescending snd
    >> Seq.mapi (fun i (c, _) -> 
        if i < 26 then c, freqCode.[i]
        else c, '?')
    >> Map.ofSeq

// Krypton 0:
printfn "Krypton 1: %s" <| b64decode "S1JZUFRPTklTR1JFQVQ="

// Krypton 1:
printfn "Krypton 2: %s" <| rot 13 "YRIRY GJB CNFFJBEQ EBGGRA"

// Krypton 2:
printfn "Krypton 3: %s" <| rot -12 "OMQEMDUEQMEK"

// Krypton 3:
let map = 
    [1..3] 
    |> List.map (sprintf "./krypton/found%i" >> File.ReadAllText >> fun s -> s.Replace (" ", "")) 
    |> String.concat "" |> freqDecode
let decoded = 
    "KSVVW BGSJD SVSIS VXBMN YQUUK BNWCU ANMJS".ToCharArray() 
    |> Array.map (fun c -> if Map.containsKey c map then map.[c] else '?') |> String
printfn "Krypton 4: %s" decoded
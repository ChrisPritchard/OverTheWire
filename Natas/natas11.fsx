open System

let encoded = "ClVLIh4ASCsCBE8lAxMacFMZV2hdVVotEhhUJQNVAmhSEV4sFxFeaAw="
let json = "{\"showpassword\":\"no\",\"bgcolor\":\"#ffffff\"}"

let base64_decode s = System.Convert.FromBase64String s |> Array.map char |> fun sa -> new String (sa)
let base64_encode (s: string) = s |> Seq.map byte |> Seq.toArray |> System.Convert.ToBase64String

let xor (inData: string) (key: string) =
    inData.ToCharArray ()
    |> Array.mapi (fun i c ->
        char (byte c ^^^ byte key.[1]))
    |> fun sa -> new String (sa)

let secret = xor json (base64_decode encoded)

let test1 = base64_encode (xor json secret) = encoded
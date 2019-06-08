# Natas 11

This challenge uses a cookie which controls whether the next level password can be shown. However the cookie value is scrambled using 'XOR' encryption: its json encoded, then xor'd with a hidden secret, then base64 encoded.

1. Go to [http://natas11.natas.labs.overthewire.org](http://natas11.natas.labs.overthewire.org)
2. Log in with natas11, U82q5TCMMQ9xuFoI3dYX61s7OZD9JKoK
3. 

Initial cookie with default data is: ClVLIh4ASCsCBE8lAxMacFMZV2hdVVotEhhUJQNVAmhSEV4sFxFeaAw
This cookie is generated from json that looks like: `{"showpassword":"no","bgcolor":"#ffffff"}`
To find the secret we need to base64 decode the cookie value, then 'xor decrypt' it against the json to get the secret.
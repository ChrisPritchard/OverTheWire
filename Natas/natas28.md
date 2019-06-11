# Natas 28

To see the site:

1. Go to [http://natas28.natas.labs.overthewire.org](http://natas28.natas.labs.overthewire.org)
2. Log in with natas28, JWwR438wkgTsNKBbcJoowyysdM82YjeF

Initial observations from submitting something to the form is that the query parameter on the redirected-to form needs to be altered. Its our entry point - our source. There doesn't seem to be any other ways in.
The string looks base64, but when decoding I get nothing. Tried several different encodings to no luck. Then I submitted just some random text, and got the error 'Incorrect amount of PKCS#7 padding for blocksize' displayed.

Cool, so its an encrypted string. Er...

Thats about the extent of my knowledge, so I looked for a tip and found out that the vuln to exploit is an 'ECB attack'.

G+glEae6W/1XjA7vRm21nNyEco/c+J2TdR0Qp8dcjPJaqeuLbHD2JDHPyKLktXEFc4pf+0pFACRndRda5Za71vNN8znGntzhH2ZQu87WJwI=
G+glEae6W/1XjA7vRm21nNyEco/c+J2TdR0Qp8dcjPJaqeuLbHD2JDHPyKLktXEFtBWBBmwHDZMabpsJNVb/DSkofzzFR54S5m8xyGOxgEdW1XMtyMdw9kOXFYvBem5m
G+glEae6W/1XjA7vRm21nNyEco/c+J2TdR0Qp8dcjPJaqeuLbHD2JDHPyKLktXEFfltOT3a4zKBPvHc83YmfkQDkmZ3Y6KyXXEH/PHuE4AZCV6ND2q2q8sDjodcc4D3Re3usplXymKMh6Q4/emDU2A==
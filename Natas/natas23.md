# Natas 23

To see the site:

1. Go to [http://natas23.natas.labs.overthewire.org](http://natas23.natas.labs.overthewire.org)
2. Log in with natas23, D0vlad33nQF0Hz2EP255TP5wSW9ZsRSE

The script will return the password if 'rehelio' is passed as a get/querystring parameter. However if the user does not contain a valid session with admin a redirect header (Location) is appended which sends the user back to the start screen.

Firefox and some frameworks (looking at you .NET) follow 302s automatically. Curl however does not.

3. To get the password, run the following command from bash: `curl --user natas22:chG9fbe1Tq2eWVMgjYYD1MsfIvN461kJ http://natas22.natas.labs.overthewire.org/?revelio`
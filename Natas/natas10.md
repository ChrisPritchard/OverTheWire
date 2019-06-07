# Natas 10

1. Go to [http://natas10.natas.labs.overthewire.org](http://natas10.natas.labs.overthewire.org)
2. Log in with natas10, nOpp1igQAkUzaI1GUUjzn1bFVj7xCNzu
3. This is the same as the previous challenge, but ;, / and & are checked for. This is no problem.
4. Instead use the grep to read the password file. Just go through random letters until you find one inside the password file. E.g.: `c /etc/natas_webpass/natas11 #`
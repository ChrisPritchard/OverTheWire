#!/usr/bin/expect -f

spawn ssh -p 2220 bandit29@bandit.labs.overthewire.org
expect "*: "
send "bbc96594b4e001778eee9975372716b2\r"
expect "*\$ "

interact
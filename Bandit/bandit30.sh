#!/usr/bin/expect -f

spawn ssh -p 2220 bandit30@bandit.labs.overthewire.org
expect "*: "
send "5b90576bedb2cc04c86a9e924ce42faf\r"
expect "*\$ "

interact
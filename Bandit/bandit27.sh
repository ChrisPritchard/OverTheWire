#!/usr/bin/expect -f

spawn ssh -p 2220 bandit27@bandit.labs.overthewire.org
expect "*: "
send "3ba3118a22e93127a4ed485be72ef5ea\r"
expect "*\$ "
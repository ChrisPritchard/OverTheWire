#!/usr/bin/expect -f

spawn ssh -l bandit17 -p 2220 bandit.labs.overthewire.org
expect "*: "
send "xLYVMN9WE5zQ5vHacb0sZEVqbrp7nBTn\r"
expect "*\$ "

interact
#send "exit\r"

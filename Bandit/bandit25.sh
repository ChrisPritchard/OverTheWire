#!/usr/bin/expect -f

spawn ssh -p 2220 bandit25@bandit.labs.overthewire.org
expect "*: "
send "uNG9O58gUE7snukf3bvZ0rxhtnjzSGzG\r"
expect "*\$ "

interact
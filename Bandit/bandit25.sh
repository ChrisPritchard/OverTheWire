#!/usr/bin/expect -f

spawn ssh -p 2220 bandit25@bandit.labs.overthewire.org
expect "*: "
send "uNG9O58gUE7snukf3bvZ0rxhtnjzSGzG\r"
expect "*\$ "

send "cat /etc/passwd | grep bandit26\r"
expect "*\$ "
send "file /usr/bin/showtext\r"
expect "*\$ "
send "cat /usr/bin/showtext\r"
expect "*\$ "

# by resizing the terminal to a tiny size more will not finish
# then we can run v to get into vi, then :e cat /etc/bandit_pass/bandit26 to get 5czgV9L3Xx8JPOyRbXh6lQbmIOWvPT6Z

interact
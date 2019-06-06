#!/usr/bin/expect -f

spawn ssh -p 2220 bandit27@bandit.labs.overthewire.org
expect "*: "
send "3ba3118a22e93127a4ed485be72ef5ea\r"
expect "*\$ "

send "mkdir /tmp/git27\r"
expect "*\$ "

send "git clone ssh://bandit27-git@localhost/home/bandit27-git/repo /tmp/exploit27\r"
expect "*(yes/no)? "
send "yes\r"
expect "*password: "
send "3ba3118a22e93127a4ed485be72ef5ea\r"
expect "*\$ "

send "ls /tmp/exploit27\r"
expect "*\$ "
send "cat /tmp/exploit27/README\r"
expect "*\$ "
send "rm -rf /tmp/exploit27\r"
expect "*\$ "
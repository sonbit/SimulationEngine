namespace SimulationEngine.REBEL2.Programs;

public static class MachineCodeDebug
{
    public static string GetString()
    {
        return """
            # ROM PAGE 1: RESET RAM & LOAD CONSTANTS. In the future load constant in furthest neg. registers to max room for stack?
            01-0--++00-- #ADDi x0, x-4, ++ (to set x0 to 0)
            110000000000
            01-0000-0+-- #ADDi x1, x-0, 0- (constant value in x1)
            110000000000
            01-000-0+--- #ADDi x2, x-0, -0 (constant value in x2)
            110000000000

            01-0--++00-- #ADDi x0, x-4, ++ (fillers ..)
            110000000000
            01-0--++00-- #ADDi x0, x-4, ++
            110000000000
            01-0--++00-- #ADDi x0, x-4, ++
            110000000000

            01-0--++00-- #ADDi x0, x-4, ++
            110000000000
            01-0--++00-- #ADDi x0, x-4, ++
            110000000000
            01-0--++00-- #ADDi x0, x-4, ++
            110000000000
    
            #START EXECUTING INSTRUCTIONS
            000000000000 #instruction at PC address --
            100000000000
            000000000000 #instruction at PC address -0
            100000000000
            000000000000 #instruction at PC address -+
            100000000000

            000000000000 #instruction at PC address 0-
            100000000000
            000000000000 #instruction at PC address 00
            100000000000
            000000000000 #instruction at PC address 0+
            100000000000

            000000000000 #instruction at PC address +-
            100000000000
            000000000000 #instruction at PC address +0  
            100000000000
            000000000000 #instruction at PC address ++
            100000000000

            # ROM PAGE 2: TEST REBEL-2 INSTRUCTIONS -- to 00 
    
            #TEST OPCODE -- (ADD/SUB/STI)
            01--000+--00 #1. ADD (x-4) =  (x0) plus (x1)- => write 0- into x-4 
            110000000000
            01--000+-0-- #2. SUB/STI (x-3) = (x0) minus (x1) => write 0+ into x-3
            110000000000
    
            #TEST OPCODE -0 (ADDi) 
            01-000++-+-- #3. ADDi (x-2) = (x0) plus ++ => write ++ into x-2
            110000000000
            01-000000000 #4. NOP (x-0) = (x0) plus 00 => write 00 into x0 (note that we can write something to it, but the hardwired 00 makes READING always zero)
            110000000000
    
            #TEST OPCODE -+ (ADDi2) not implemented yet

            #TEST OPCODE 0- (MUDI) Multiplication in lower region (so outcome cannot exceed 4 or -4)
            010-+-0+0-00 #5. MUDI (x-1) = (x2) * (x1) => write +0 into x-1
            110000000000

            #TEST OPCODE 0- (MUDI) Division not implemented yet

            #TEST OPCODE 00 (MIMA) MIN/MAX (Ternary AND/OR)
            0100+-0++0-- #6. MIN-WORDWISE (x3) = MIN((x2),(x1)) => write -0 into x3
            110000000000
            01000+0+++-0 #7. MIN-TRITWISE (x4) = MINi((x1),(x1)) => write 0- into x4
            110000000000
            0100+-0++0+- #8. MAX-WORDWISE (x3) = MAX((x2),(x1)) => write 0- into x3
            110000000000
            0100+-+-+++0 #9. MAX-TRITWISE (x4) = MAXi((x2),(x2)) => write -0 into x4
            110000000000
    
            #START EXECUTING INSTRUCTIONS
            000000000000 #instruction at PC address --
            100000000000
            000000000000 #instruction at PC address -0
            100000000000
            000000000000 #instruction at PC address -+
            100000000000

            000000000000 #instruction at PC address 0-
            100000000000
            000000000000 #instruction at PC address 00
            100000000000
            000000000000 #instruction at PC address 0+
            100000000000

            000000000000 #instruction at PC address +-
            100000000000
            000000000000 #instruction at PC address +0  
            100000000000
            000000000000 #instruction at PC address ++
            100000000000

            # ROM PAGE 3: TEST REBEL-2 INSTRUCTIONS 0+ to ++ 
    
            #TEST OPCODE 0+ (SHIFT)
            010+--0+--00 #1. SHI (x-4) = SHIFT (x-4) with 1 pos to cyclic -> 0- becomes -0     
            110000000000
            010+-00+-0-+ #2. SHI (x-3) = SHIFT (x-3) with 1 pos to left, add + becomes ++
            110000000000
            010+-++--++- #3. SHI (x-2) = SHIFT (x-2) with 2 pos to right, add - becomes --
            110000000000


            #TEST OPCODE +- (COMP) 
            01+-0++-0-00 #4. COMP (x-1) = COMP( (x1),(x2)) => 0- < -0 write -- into x-1
            110000000000
            01+-0+000-++ #5. COMPi (x-1) = COMPi( (x1),(x0)) => 0- << 00 write 0+ into x-1
            110000000000
    
            #TEST OPCODE +0 (BCEG) 
            01+0++++0+00 #6. BCEG test equal x4 and x4 (goto PC + imm if equal PC + 00 if greater =) 
            110000000000
            01+0+0++000+ #7. BCEG test equal x3 and x4 (goto x0 if equal x4 if greater) -1 > -3 
            110000000000
            01+0+++00000 #8. BCEG test smaller x4 and x3 (goto x0 if equal x4 if greater, no goto if smaller) -3 > -1 
            110000000000
 
            #TEST OPCODE ++ (PCO)
            01++00-0++0+ #9. PCO JAL test x4 = PC +1 plus jump to PC + imm
            110000000000
    
            #START EXECUTING INSTRUCTIONS
            000000000000 #instruction at PC address --
            100000000000
            000000000000 #instruction at PC address -0
            100000000000
            000000000000 #instruction at PC address -+
            100000000000

            000000000000 #instruction at PC address 0-
            100000000000
            000000000000 #instruction at PC address 00
            100000000000
            000000000000 #instruction at PC address 0+
            100000000000

            000000000000 #instruction at PC address +-
            100000000000
            000000000000 #instruction at PC address +0  
            100000000000
            000000000000 #instruction at PC address ++
            100000000000


            # ROM PAGE 4: TEST REBEL-2 INSTRUCTIONS ++ and MISC
            01++0000++0- #1. PCO AUIPC test x4 = PC + imm plus no jump
            110000000000
            01++00--0000 #2. PCO JALR/JUMP test x0 = PC +1 plus jump to PC + imm (RESET to --)
            110000000000
            010000000000 #3. NOP
            110000000000
            010000000000 #4. NOP
            110000000000
            010000000000 #5. NOP
            110000000000
            010000000000 #6. NOP
            110000000000
            010000000000 #7. NOP
            110000000000
            010000000000 #8. NOP
            110000000000
            010000000000 #9. NOP
            110000000000


   
            #START EXECUTING INSTRUCTIONS
            000000000000 #instruction at PC address --
            100000000000
            000000000000 #instruction at PC address -0
            100000000000
            000000000000 #instruction at PC address -+
            100000000000

            000000000000 #instruction at PC address 0-
            100000000000
            000000000000 #instruction at PC address 00
            100000000000
            000000000000 #instruction at PC address 0+
            100000000000

            000000000000 #instruction at PC address +-
            100000000000
            000000000000 #instruction at PC address +0  
            100000000000
            000000000000 #instruction at PC address ++
            100000000000
        """;
    }
}
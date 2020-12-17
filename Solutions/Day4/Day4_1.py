import re

class Day4_1(object):
    #passport attribs - mandatory
    byr = 0
    iyr = 0
    eyr = 0
    hgt = 0
    hcl = 0
    ecl = 0
    pid = 0
    #passport attribs - optional
    cid = 0
    #number of valid passports
    validPassports = 0
    invalidPassports = 0

    #valid eye colours
    eyeColours = ["amb", "blu", "brn", "gry", "grn", "hzl", "oth"]

    def checkPassportAndResetAttributes(self):
        if self.byr == 1 and self.iyr == 1 and self.eyr == 1 and self.hgt == 1 and self.hcl == 1 and self.ecl == 1 and self.pid == 1:
            print('Complete passport found')
            self.validPassports += 1
        else:
            print('Incomplete passport found')
            self.invalidPassports += 1
        self.byr = 0
        self.iyr = 0
        self.eyr = 0
        self.hgt = 0
        self.hcl = 0
        self.ecl = 0
        self.pid = 0
        self.cid = 0

    def processFile(self):
        print('Reading file')

        fileName = 'Day4_1.txt'

        passportFile = open(fileName, 'r')

        passportLines = passportFile.readlines()

        for line in passportLines:
            if line == '\n':
                print('New passport found')
                self.checkPassportAndResetAttributes()
            else:
                tokens = line.split(' ')
                for token in tokens:
                    pair = token.rstrip().split(':')
                    print("Found token key: " + pair[0] + " value: " + pair[1])
                    if pair[0] == 'byr':
                        if len(str(int(pair[1]))) == 4 and int(pair[1]) >= 1920 and int(pair[1]) <= 2002 and int(pair[1]) != 0:
                            self.byr = 1
                        else:
                            print(f"Disqualified byr based on {pair[1]}")
                    if pair[0] == 'iyr':
                        if len(str(int(pair[1]))) == 4 and int(pair[1]) >= 2010 and int(pair[1]) <= 2020 and int(pair[1]) != 0:
                            self.iyr = 1
                        else:
                            print(f"Disqualified iyr based on {pair[1]}")
                    if pair[0] == 'eyr':
                        if len(str(int(pair[1]))) == 4 and int(pair[1]) >= 2020 and int(pair[1]) <= 2030 and int(pair[1]) != 0:
                            self.eyr = 1
                        else:
                            print(f"Disqualified eyr based on {pair[1]}")
                    if pair[0] == 'hgt':
                        if 'in' in pair[1]:
                            if int(pair[1].replace('in','')) >= 59 and int(pair[1].replace('in','')) <= 76:
                                self.hgt = 1
                            else:
                                print(f"Disqualified hgt-in based on {pair[1]}")
                        if 'cm' in pair[1]:
                            if int(pair[1].replace('cm','')) >= 150 and int(pair[1].replace('cm','')) <= 193:
                                self.hgt = 1
                            else:
                                print(f"Disqualified hgt-cm based on {pair[1]}")
                    if pair[0] == 'hcl':
                        if len(str(pair[1])) == 7 and re.match(r'#[0-9a-f]{6}', pair[1]) is not None:
                            self.hcl = 1
                        else:
                            print(f"Disqualified hcl based on {pair[1]}")
                    if pair[0] == 'ecl':
                        if pair[1] in ["amb", "blu", "brn", "gry", "grn", "hzl", "oth"]:
                            self.ecl = 1
                        else:
                            print(f"Disqualified ecl based on {pair[1]} of length {len(str(pair[1]))}")
                    if pair[0] == 'pid':
                        if len(str(pair[1])) == 9 and re.search(r'[0-9]{9}', str(pair[1])) is not None:
                            self.pid = 1
                        else:
                            print(f"Disqualified pid based on {pair[1]} length {len(str(pair[1]))}")
                    if pair[0] == 'cid':
                        self.cid = 1
        self.checkPassportAndResetAttributes()
        print(f"Number of complete passports: {self.validPassports}")
        print(f"Number of incomplete passports: {self.invalidPassports}")




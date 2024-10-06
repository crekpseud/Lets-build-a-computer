using HardwareEmulator.Lib.Factories.AddersFactories;

namespace HardwareEmulator.Lib.Adders;

public class EightBitAdder(IFullAdderFactory fullAdderFactory) : NBitAdder(fullAdderFactory, 8);

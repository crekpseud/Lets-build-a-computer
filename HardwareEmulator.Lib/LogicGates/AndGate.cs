﻿using HardwareEmulator.Lib.Factories;

namespace HardwareEmulator.Lib.LogicGates;

public class AndGate
{
    private readonly Relay[] _relays;

    public AndGate(IRelayFactory relayFactory, int numberOfInputs)
    {
        _relays = relayFactory.CreateArray(false, numberOfInputs);
    }

    public void SetInput(int index, bool bit)
    {
        if (bit)
        {
            _relays[index].EnergyOn();
        }
        else
        {
            _relays[index].EnergyOff();
        }
    }

    public void SetInputs(bool[] bits)
    {
        for (int i = 0; i < _relays.Length; i++)
        {
            if (bits[i])
            {
                _relays[i].EnergyOn();
            }
            else
            {
                _relays[i].EnergyOff();
            }
        }
    }

    public bool GetOutput()
    {
        return Array.TrueForAll(_relays, r => r.IsEnergized);
    }
}

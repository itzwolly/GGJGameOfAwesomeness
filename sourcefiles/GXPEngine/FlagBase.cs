using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

public class FlagBase : Sprite
{
    private bool _active = true;
    private State _baseState;

    public enum State {
        NEUTRAL,
        PLAYERONE_SPOTONE,
        PLAYERONE_SPOTTWO,
        PLAYERTWO_SPOTONE,
        PLAYERTWO_SPOTTWO
    }

    public bool IsActive {
        get { return _active; }
        set { _active = value; }
    }

    public FlagBase(string pFileName, State pState) : base(pFileName) {
        _baseState = pState;
        SetOrigin(width / 2, height / 2);

        switch (_baseState) {
             case State.NEUTRAL:
                x = game.width / 2;
                y = game.height / 2;

                Console.WriteLine(game.width);
                break;
            case State.PLAYERONE_SPOTONE:
                x = 100;
                y = 100;
                break;
            case State.PLAYERONE_SPOTTWO:
                x = 100;
                y = game.height - 100;
                break;
            case State.PLAYERTWO_SPOTONE:
                x = game.width - 100;
                y = 100;
                break;
            case State.PLAYERTWO_SPOTTWO:
                x = game.width - 100;
                y = game.height - 100;
                break;
            default:
                break;
        }
    }

    public State GetBaseState() {
        return _baseState;
    }

    public string GetUsedFlagBaseSprite(State pFlagState) {
        switch (pFlagState) {
            case State.PLAYERONE_SPOTONE:
            case State.PLAYERONE_SPOTTWO:
                return "base_player_one_used.png";
            case State.PLAYERTWO_SPOTONE:
            case State.PLAYERTWO_SPOTTWO:
                return "base_player_two_used.png";
            case State.NEUTRAL:
            default:
                return "";
        }
    }

    public string GetUsedFlagBaseSprite(Player pPlayer) {
        if (pPlayer.GetPlayerId() == Player.PlayerId.PLAYERONE) {
            return "base_player_one_used.png";
        } else if (pPlayer.GetPlayerId() == Player.PlayerId.PLAYERTWO) {
            return "base_player_two_used.png";
        }
        return "";
    }
}

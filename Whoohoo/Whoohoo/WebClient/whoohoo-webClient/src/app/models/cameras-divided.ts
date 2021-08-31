import { Camera } from "./camera";

export interface CamerasDivided {
    dividedByThree: Camera[];
    dividedByFive: Camera[];
    dividedByThreeAndFive: Camera[];
    notDividedByThreeAndFive: Camera[];
}